import { gql } from '@apollo/client';

/*
https://localhost:7208/graphql/
*/
export const GET_POSTS = gql`
  query GetPosts {
    posts {
      edges {
        node {
          author {
            bio
            name
            id
            photoUrl
          }
          created_At
          slug
          title
          excerpt
          featuredImageUrl
          categories {
            name
            slug
          }
        }
      }
    }
  }
`;

/*
https://localhost:7208/graphql/
http://localhost:5020
*/
export const GET_POST_DETAILS = gql`
  query GetPostDetails($slug: String!) {
    posts(where: { slug: { eq: $slug } }) {
      edges {
        node {
          id
          title
          excerpt
          featuredImageUrl
          author {
            id
            name
            bio
            photoUrl
          }
          created_At
          slug
          content
          categories {
            name
            slug
          }
        }
      }
    }
  }
`;

/*
https://localhost:8046/graphql/
*/
export const GET_RECENT_POSTS = gql`
  query GetRecentPosts {
    posts(order: { created_At: ASC }, last: 3) {
      edges {
        node {
          title
          featuredImageUrl
          created_At
          slug
        }
      }
    }
  }
`;

/*
https://localhost:8046/graphql/
*/
export const GET_SIMILAR_POSTS = gql`
  query GetSimiilarPosts($slug: String!, $categories: [String!]) {
    posts(
      where: {
        and: [
          { slug: { neq: $slug } }
          { categories: { some: { some: { slug: { in: $categories } } } } }
        ]
      }
      last: 3
    ) {
      edges {
        node {
          title
          featuredImageUrl
          created_At
          slug
        }
      }
    }
  }
`;

/*
https://localhost:8046/graphql/
*/
export const GET_CATEGORIES = gql`
  query GetCategories {
    categories {
      name
      slug
    }
  }
`;

export const GET_COMMENTS = gql`
  query GetComments {
    comments {
      id
      authorId
      postId
      content
      created_At
      updated_At
      author {
        name
      }
    }
  }
`;

export const ADD_COMMENT = gql`
  mutation AddComment(
    $postId: Int!
    $authorId: Int!
    $content: String!
    $created_At: DateTime!
    $updated_At: DateTime!
  ) {
    addComment(
      commentInput: {
        postId: $postId
        authorId: $authorId
        content: $content
        created_At: $created_At
        updated_At: $updated_At
      }
    ) {
      id
      authorId
      postId
      content
      created_At
      updated_At
      path
    }
  }
`;

export const GET_COMMENTS_BY_POST_ID = gql`
  query GetCommentsByPostId($postId: Int!) {
    comments(where: { postId: { eq: $postId } }) {
      id
      authorId
      postId
      content
      created_At
      updated_At
      path
      author {
        name
      }
    }
  }
`;
