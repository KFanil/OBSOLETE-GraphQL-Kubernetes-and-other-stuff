import React, { FC } from 'react';
import { GetPostDetails_posts_edges_node } from '../Services/graphql/__generated__/GetPostDetails';

const Author: FC<GetPostDetails_posts_edges_node> = (
  post: GetPostDetails_posts_edges_node,
) => {
  return (
    <div className="text-center mt-20 mb-8 p-12 relative rounded-lg bg-black bg-opacity-20">
      <div className="absolute left-0 right-0 -top-14">
        <img
          alt={post.author[0].name}
          height="100px"
          width="100px"
          className="align-middle rounded-full"
          src={post?.author[0].photoUrl}
        />
      </div>
      <h3 className="text-white mt-4 mb-4 text-xl font-bold">
        {post?.author[0].name}
      </h3>
      <p className="text-white text-ls">{post?.author[0].bio}</p>
    </div>
  );
};

export default Author;
