/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { PostList } from './PostList';
import { useEffect, useState } from 'react';
import { Page } from './Page';
// import { RouteComponentProps } from 'react-router-dom';
import { useQuery } from '@apollo/client';
import { GetPosts } from '../Services/graphql/__generated__/GetPosts';
import { GET_POSTS } from '../Services/graphql/queries.graphql';
import { useNavigate } from 'react-router-dom';
// import { withRouter } from 'react-router';

// interface Props extends RouteComponentProps {
//   getRecipesAsync: () => Promise<void>;
//   recipesLoading: boolean;
// }

const HomePage = () => {
  const { data } = useQuery<GetPosts>(GET_POSTS);
  const [dataLoading, setDataLoading] = useState(true);

  let navigate = useNavigate();
  const logout = () => {
    localStorage.clear();
    navigate('/login');
  };
  useEffect(() => {
    console.log(data);
    let cancelled = false;
    const doGetUnansweredQuestions = () => {
      if (!cancelled) {
        setDataLoading(false);
      }
    };
    doGetUnansweredQuestions();
    return () => {
      cancelled = true;
    };
  }, [data]);

  return (
    <Page>
      {dataLoading ? (
        <div
          css={css`
            font-size: 16px;
            font-style: italic;
          `}
        >
          Loading...
        </div>
      ) : (
        <PostList posts={data} />
      )}
    </Page>
  );
};
export default HomePage;
