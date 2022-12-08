import { gql } from '@apollo/client';

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
          { categories: { some: { slug: { in: $categories } } } }
        ]
      }
      last: 3
    ) {
      edges {
        node {
          slug
          content
          categories {
            slug
            name
          }
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
