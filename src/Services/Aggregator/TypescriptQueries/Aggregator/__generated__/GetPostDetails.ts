/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: GetPostDetails
// ====================================================

export interface GetPostDetails_posts_edges_node_author {
  __typename: "Author";
  name: string;
  bio: string;
  photoUrl: string;
}

export interface GetPostDetails_posts_edges_node_categories {
  __typename: "Posts_Posts_Edges_Node_Categories_Category";
  name: string;
  slug: string;
}

export interface GetPostDetails_posts_edges_node {
  __typename: "PostPreview";
  title: string;
  excerpt: string;
  featuredImageUrl: string;
  author: GetPostDetails_posts_edges_node_author[];
  created_At: any;
  slug: string;
  content: string;
  categories: GetPostDetails_posts_edges_node_categories[][] | null;
}

export interface GetPostDetails_posts_edges {
  __typename: "PostsEdge";
  /**
   * The item at the end of the edge.
   */
  node: GetPostDetails_posts_edges_node;
}

export interface GetPostDetails_posts {
  __typename: "PostsConnection";
  /**
   * A list of edges.
   */
  edges: GetPostDetails_posts_edges[] | null;
}

export interface GetPostDetails {
  posts: GetPostDetails_posts | null;
}

export interface GetPostDetailsVariables {
  slug: string;
}
