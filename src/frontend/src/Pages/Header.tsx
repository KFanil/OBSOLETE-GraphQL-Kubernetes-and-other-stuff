// import { UserIcon } from './Icons';
/** @jsxImportSource @emotion/react */
/** @jsx jsx @css css */
import { css, jsx } from '@emotion/react';
import { fontFamily, fontSize, gray1, gray2, gray5 } from '../Styles/Styles';
import { ChangeEvent, FC, useState, FormEvent } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useParams } from 'react-router-dom';
import { UserIcon } from '../Components/Icons';
// import { useAuth } from './Auth';

const buttonStyle = css`
  display: inline-block;
  border: none;
  font-family: ${fontFamily};
  font-size: ${fontSize};
  padding: 5px 10px;
  background-color: transparent;
  color: ${gray2};
  text-decoration: none;
  cursor: pointer;
  span {
    margin-left: 10px;
  }
  :focus {
    outline-color: ${gray5};
  }
`;

export const Header: FC = () => {
  const searchParams = useParams();
  const criteria = searchParams.criteria;

  const isAuthenticated = localStorage.getItem('auth');
  const username = localStorage.getItem('username');
  console.log(isAuthenticated);
  console.log(username);
  // let navigate = useNavigate();
  const [search, setSearch] = useState(criteria);

  const handleSearchInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.currentTarget.value);
  };

  const handleSearchSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    // navigate(`/search?criteria=${search}`);
  };

  let navigate = useNavigate();
  // const { isAuthenticated, user, loading } = useAuth();
  const logout = () => {
    localStorage.clear();
    navigate('/');
  };
  return (
    <div
      css={css`
        z-index: 999;
        /* position: fixed; */
        box-sizing: border-box;
        top: 0;
        width: 100%;
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 10px 20px;
        background-color: #fff;
        border-bottom: 1px solid ${gray5};
        box-shadow: 0 3px 7px 0 rgba(110, 112, 114, 0.21);
      `}
    >
      <Link
        to="/"
        css={css`
          font-size: 24px;
          font-weight: bold;
          color: ${gray1};
          text-decoration: none;
        `}
      >
        YJS
      </Link>
      <form onSubmit={handleSearchSubmit}>
        <input
          type="text"
          placeholder="Search..."
          onChange={handleSearchInputChange}
          value={search}
          css={css`
            box-sizing: border-box;
            font-family: ${fontFamily};
            font-size: ${fontSize};
            padding: 8px 10px;
            border: 1px solid ${gray5};
            border-radius: 3px;
            color: ${gray2};
            background-color: white;
            width: 200px;
            height: 30px;
            :focus {
              outline-color: ${gray5};
            }
          `}
        />
      </form>
      {isAuthenticated ? (
        <div>
          <span>{username}</span>
          <Link to={{ pathname: '/home' }} css={buttonStyle} onClick={logout}>
            <UserIcon />
            <span>Sign Out</span>
          </Link>
        </div>
      ) : (
        <Link to="/login" css={buttonStyle}>
          <UserIcon />
          <span>Sign In</span>
        </Link>
      )}
    </div>
  );
};

export default Header;
