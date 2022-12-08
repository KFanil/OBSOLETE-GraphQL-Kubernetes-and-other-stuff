import React, { useState, useEffect, FC } from 'react';
import moment from 'moment';
import {
  GET_RECENT_POSTS,
  GET_SIMILAR_POSTS,
} from '../Services/graphql/queries.graphql';
import { useLazyQuery, useQuery } from '@apollo/client';
import { GetSimiilarPosts } from '../Services/graphql/__generated__/GetSimiilarPosts';
import { GetRecentPosts } from '../Services/graphql/__generated__/GetRecentPosts';
import { Link } from 'react-router-dom';

// import { grpahCMSImageLoader } from '../util';
// import { getSimilarPosts, getRecentPosts } from '../services';

interface Props {
  categories?: string[];
  slug?: string;
}

export const PostWidget: FC<Props> = ({ categories, slug }) => {
  const [relatedPosts, setRelatedPosts] = useState<GetSimiilarPosts>();

  const [searchSimilarPosts, { data: similarPosts }] =
    useLazyQuery(GET_SIMILAR_POSTS);
  const [searchRecentPosts, { data: RecentPosts }] =
    useLazyQuery(GET_RECENT_POSTS);

  useEffect(() => {
    if (slug) {
      searchSimilarPosts({
        variables: { slug: slug, categories: categories },
      }).then((result) => {
        setRelatedPosts(result.data);
      });
    } else {
      searchRecentPosts().then((result) => {
        setRelatedPosts(result.data);
      });
    }
  }, [categories, searchRecentPosts, searchSimilarPosts, slug]);

  return (
    <div className="bg-white shadow-lg rounded-lg p-8 pb-12 mb-8">
      <h3 className="text-xl mb-8 font-semibold border-b pb-4">
        {slug ? 'Related Posts' : 'Recent Posts'}
      </h3>
      {relatedPosts?.posts!.edges!.map((edge, index) => (
        <div key={index} className="flex items-center w-full mb-4">
          <div className="w-16 flex-none">
            <img
              alt={edge.node.title}
              height="60px"
              width="60px"
              className="align-middle rounded-full"
              src={edge.node.featuredImageUrl}
            />
          </div>
          <div className="flex-grow ml-4">
            <p className="text-gray-500 font-xs">
              {moment(edge.node.created_At).format('MMM DD, YYYY')}
            </p>
            <Link
              to={`/post/${edge.node.slug}`}
              className="text-md"
              key={index}
            >
              {edge.node.title}
            </Link>
          </div>
        </div>
      ))}
    </div>
  );
};
