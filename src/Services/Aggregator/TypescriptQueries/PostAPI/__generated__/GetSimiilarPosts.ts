/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: GetSimiilarPosts
// ====================================================

export interface GetSimiilarPosts_posts_edges_node_categories {
  __typename: "Category";
  slug: string;
  name: string;
}

export interface GetSimiilarPosts_posts_edges_node {
  __typename: "Post";
  slug: string;
  content: string;
  /**
   * This is the list of categories
   */
  categories: GetSimiilarPosts_posts_edges_node_categories[][] | null;
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
