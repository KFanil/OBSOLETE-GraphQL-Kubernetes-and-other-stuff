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
          title
          excerpt
          featuredImageUrl
          author {
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
