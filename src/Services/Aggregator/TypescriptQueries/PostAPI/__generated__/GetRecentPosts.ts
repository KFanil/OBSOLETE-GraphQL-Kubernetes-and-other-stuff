/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: GetRecentPosts
// ====================================================

export interface GetRecentPosts_posts_edges_node {
  __typename: "Post";
  title: string;
  featuredImageUrl: string;
  created_At: any;
  slug: string;
}

export interface GetRecentPosts_posts_edges {
  __typename: "PostsEdge";
  /**
   * The item at the end of the edge.
   */
  node: GetRecentPosts_posts_edges_node;
}

export interface GetRecentPosts_posts {
  __typename: "PostsConnection";
  /**
   * A list of edges.
   */
  edges: GetRecentPosts_posts_edges[] | null;
}

export interface GetRecentPosts {
  posts: GetRecentPosts_posts | null;
}
