import { FC } from 'react';
import Categories from '../Components/Categories';
import { PostWidget } from '../Components/PostWidget';
import {
  GetPosts,
  GetPosts_posts_edges_node,
} from '../Services/graphql/__generated__/GetPosts';
import Post from './Post';

interface Props {
  posts: GetPosts | undefined;
  renderItem?: (item: GetPosts_posts_edges_node) => JSX.Element;
}

export const PostList: FC<Props> = ({ posts, renderItem }) => {
  return (
    <div className="container mx-auto px-10 mb-8">
      {/* <FeaturedPosts /> */}
      <div className="grid grid-cols-1 lg:grid-cols-12 gap-12">
        <div className="lg:col-span-5 col-span-5">
          {posts?.posts?.edges!.map((post, index) => (
            <Post key={index} post={post.node} />
          ))}
        </div>
        <div className="lg:col-span-4 col-span-1">
          <div className="lg:sticky relative top-8">
            <PostWidget />
            <Categories />
          </div>
        </div>
      </div>
    </div>
  );
};
