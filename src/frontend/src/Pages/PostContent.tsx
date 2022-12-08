import { useLazyQuery, useQuery } from '@apollo/client';
/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import Author from '../Components/Author';
import Categories from '../Components/Categories';
import Comments from '../Components/Comments';
import CommentsForm from '../Components/CommentsForm';
import PostDetail from '../Components/PostDetail';
import Post from '../Components/PostDetail';
import { PostWidget } from '../Components/PostWidget';
import { GetPostDetails } from '../Services/graphql/__generated__/GetPostDetails';
import {
  GET_POSTS,
  GET_POST_DETAILS,
} from '../Services/graphql/queries.graphql';
import { Page } from './Page';
import { GetPosts } from '../Services/graphql/__generated__/GetPosts';

// import { PostDetail, Categories, PostWidget, Author, Comments, CommentsForm, Loader } from '../../components';
// import { getPosts, getPostDetails } from '../../services';
// import { AdjacentPosts } from '../../sections';

const PostContent = () => {
  // const router = useRouter();

  const searchParams = useParams();
  const slug = searchParams.slug;
  // if (router.isFallback) {
  //   return <Loader />;
  // }

  const [postDetails, setPostDetails] = useState<GetPostDetails>();
  const [getPostDetails] = useLazyQuery(GET_POST_DETAILS);
  const [dataLoading, setDataLoading] = useState(true);

  useEffect(() => {
    if (slug) {
      getPostDetails({
        variables: { slug: slug },
      }).then((result) => {
        console.log(result.data);
        setPostDetails(result.data);
        setDataLoading(false);
      });
    }
  }, [getPostDetails, slug]);

  const isAuthenticated = localStorage.getItem('auth');

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
        <div className="container mx-auto px-10 mb-8">
          <div className="grid grid-cols-1 lg:grid-cols-12 gap-12">
            <div className="col-span-1 lg:col-span-8">
              <PostDetail {...postDetails!?.posts?.edges![0].node!} />
              <Author {...postDetails!?.posts?.edges![0].node!} />
              {/* <AdjacentPosts slug={post.slug} createdAt={post.createdAt} /> */}

              {!isAuthenticated ? (
                <div></div>
              ) : (
                <CommentsForm
                  postId={postDetails!?.posts?.edges![0].node!.id!}
                  authorId={postDetails!?.posts?.edges![0].node!.author[0].id!}
                />
              )}

              <Comments postId={postDetails!?.posts?.edges![0].node!.id!} />
            </div>
            <div className="col-span-1 lg:col-span-4">
              <div className="relative lg:sticky top-8">
                {/* <PostWidget slug={post.slug} categories={post.categories.map((category) => category.slug)} /> */}
                <PostWidget />
                <Categories />
              </div>
            </div>
          </div>
        </div>
      )}
    </Page>
  );
};
export default PostContent;
