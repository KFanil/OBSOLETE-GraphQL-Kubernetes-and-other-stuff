/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: GetComments
// ====================================================

export interface GetComments_comments_author {
  __typename: "Author";
  name: string;
}

export interface GetComments_comments {
  __typename: "Comment";
  id: number;
  authorId: number;
  postId: number;
  content: string;
  created_At: any;
  updated_At: any;
  author: GetComments_comments_author[];
}

export interface GetComments {
  comments: GetComments_comments[];
}
