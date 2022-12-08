/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: GetSimiilarPosts
// ====================================================

export interface GetSimiilarPosts_posts_edges_node {
  __typename: "PostPreview";
  title: string;
  featuredImageUrl: string;
  created_At: any;
  slug: string;
}

export interface GetSimiilarPosts_posts_edges {
  __typename: "PostsEdge";
  /**
   * The item at the end of the edge.
   */
  node: GetSimiilarPosts_posts_edges_node;
}

export interface GetSimiilarPosts_posts {
  __typename: "PostsConnection";
  /**
   * A list of edges.
   */
  edges: GetSimiilarPosts_posts_edges[] | null;
}

export interface GetSimiilarPosts {
  posts: GetSimiilarPosts_posts | null;
}

export interface GetSimiilarPostsVariables {
  slug: string;
  categories?: string[] | null;
}
