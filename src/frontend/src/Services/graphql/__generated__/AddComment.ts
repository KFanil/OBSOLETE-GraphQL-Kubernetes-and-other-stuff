/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL mutation operation: AddComment
// ====================================================

export interface AddComment_addComment {
  __typename: "Comment";
  id: number;
  authorId: number;
  postId: number;
  content: string;
  created_At: any;
  updated_At: any;
  path: string;
}

export interface AddComment {
  addComment: AddComment_addComment;
}

export interface AddCommentVariables {
  postId: number;
  authorId: number;
  content: string;
  created_At: any;
  updated_At: any;
}
