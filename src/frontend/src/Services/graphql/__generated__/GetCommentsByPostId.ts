/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: GetCommentsByPostId
// ====================================================

export interface GetCommentsByPostId_comments_author {
  __typename: "Author";
  name: string;
}

export interface GetCommentsByPostId_comments {
  __typename: "Comment";
  id: number;
  authorId: number;
  postId: number;
  content: string;
  created_At: any;
  updated_At: any;
  path: string;
  author: GetCommentsByPostId_comments_author[];
}

export interface GetCommentsByPostId {
  comments: GetCommentsByPostId_comments[];
}

export interface GetCommentsByPostIdVariables {
  postId: number;
}
