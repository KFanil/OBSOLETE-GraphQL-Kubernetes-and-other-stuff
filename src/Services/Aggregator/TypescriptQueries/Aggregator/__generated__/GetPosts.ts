/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: GetPosts
// ====================================================

export interface GetPosts_posts_edges_node_author {
  __typename: "Author";
  bio: string;
  name: string;
  id: number;
  photoUrl: string;
}

export interface GetPosts_posts_edges_node_categories {
  __typename: "Posts_Posts_Edges_Node_Categories_Category";
  name: string;
  slug: string;
}

export interface GetPosts_posts_edges_node {
  __typename: "PostPreview";
  author: GetPosts_posts_edges_node_author[];
  created_At: any;
  slug: string;
  title: string;
  excerpt: string;
  featuredImageUrl: string;
  categories: GetPosts_posts_edges_node_categories[][] | null;
}

export interface GetPosts_posts_edges {
  __typename: "PostsEdge";
  /**
   * The item at the end of the edge.
   */
  node: GetPosts_posts_edges_node;
}

export interface GetPosts_posts {
  __typename: "PostsConnection";
  /**
   * A list of edges.
   */
  edges: GetPosts_posts_edges[] | null;
}

export interface GetPosts {
  posts: GetPosts_posts | null;
}
