import React, { FC, useEffect, useState } from 'react';
import moment from 'moment';
/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';

import { GET_COMMENTS_BY_POST_ID } from '../Services/graphql/queries.graphql';
import {
  GetCommentsByPostId,
  GetCommentsByPostId_comments,
} from '../Services/graphql/__generated__/GetCommentsByPostId';
import { useLazyQuery } from '@apollo/client';
import { Page } from '../Pages/Page';
import {
  HubConnectionBuilder,
  HubConnectionState,
  HubConnection,
} from '@aspnet/signalr';

interface Props {
  postId: number;
}

const Comments: FC<Props> = ({ postId }) => {
  const [comments, setComments] = useState<GetCommentsByPostId>();
  const [getCommentsByPostId] = useLazyQuery(GET_COMMENTS_BY_POST_ID);
  const [dataLoading, setDataLoading] = useState(true);

  const setUpSignalRConnection = async (recipeId: number) => {
    const connection = new HubConnectionBuilder()
      .withUrl('http://acme.com/hub/commentsnotificationhub')
      .withAutomaticReconnect()
      .build();

    connection.on('Message', (message: string) => {
      console.log('Message', message);
    });
    connection.on('ReceiveComment', (comment: GetCommentsByPostId_comments) => {
      console.log('ReceiveComment', comment);
      try {
        if (comments && comments.comments.length > 0) {
          comments!.comments = comments!.comments.concat(comment);
          setComments(comments);
        }
      } catch (err) {
        console.log(err);
      }
    });
    try {
      await connection.start();
    } catch (err) {
      console.log(err);
    }
    if (connection.state === HubConnectionState.Connected) {
      connection.invoke('SubscribePost', recipeId).catch((err: Error) => {
        return console.error(err.toString());
      });
    }

    return connection;
  };

  const cleanUpSignalRConnection = async (
    recipeId: number,
    connection: HubConnection,
  ) => {
    if (connection.state === HubConnectionState.Connected) {
      try {
        await connection.invoke('UnsubscribePost', recipeId);
      } catch (err) {
        return console.error('Error');
      }
      connection.off('Message');
      connection.off('ReceiveComment');
      connection.stop();
    } else {
      connection.off('Message');
      connection.off('ReceiveComment');
      connection.stop();
    }
  };

  useEffect(() => {
    let connection: HubConnection;
    if (postId) {
      getCommentsByPostId({
        variables: { postId: postId },
      }).then((result) => {
        console.log('postId:' + postId);
        console.log(result.data);
        setComments(result.data);
        setDataLoading(false);
      });
      setUpSignalRConnection(postId).then((con) => {
        connection = con;
      });
    }
    return function cleanUp() {
      if (postId) {
        cleanUpSignalRConnection(postId, connection);
      }
    };
  }, [getCommentsByPostId, postId]);

  return (
    <Page>
      {dataLoading ? (
        <div
          css={css`
            font-size: 16px;
            font-style: italic;
          `}
        >
          Loading...
        </div>
      ) : (
        <div className="bg-white shadow-lg rounded-lg p-8 pb-12 mb-8">
          <h3 className="text-xl mb-8 font-semibold border-b pb-4">
            {comments?.comments.length} Comments
          </h3>
          {comments?.comments.map((comment, index) => (
            <div key={index} className="border-b border-gray-100 mb-4 pb-4">
              <p className="mb-4">
                <span className="font-semibold">{comment.author[0]!.name}</span>{' '}
                on {moment(comment.created_At).format('MMM DD, YYYY')}
              </p>
              <p className="whitespace-pre-line text-gray-600 w-full">
                {comment.content}
              </p>
            </div>
          ))}
        </div>
      )}
    </Page>
  );
};

export default Comments;
