import React from 'react';
import './App.css';
import { Header } from './Pages/Header';
import { BrowserRouter, Route, Navigate, Link, Routes } from 'react-router-dom';
import { useClient } from './Services/client';
import { ApolloProvider } from '@apollo/client';
import HomePage from './Pages/HomePage';
import { PostWidget } from './Components/PostWidget';
import PostContent from './Pages/PostContent';
import { NotFoundPage } from './Pages/NotFoundPage';
import SignUp from './Components/Auth/Components/SignUp';
import Login from './Components/Auth/Components/Login';

const App: React.FC = () => {
  const apolloClient = useClient();
  return (
    <ApolloProvider client={apolloClient}>
      <BrowserRouter>
        <Header />
        <Routes>
          {/* <div>
            <Helmet>
          <meta charSet="utf-8" />
          <title>My Title</title>
          <link
            rel="stylesheet"
            href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css"
          />
          <link
            rel="stylesheet"
            href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"
          />
        </Helmet>
          </div> */}
          <Route path="/" element={<Navigate replace to="/home" />} />
          <Route path="/home" element={<HomePage />} />
          {/* <Route path="/search" component={SearchPage} />
         <Route path="/signin" render={() => <SignInPage action="signin" />} />
          <Route path="/signin-callback" component={HomePage} />
          <Route
            path="/signout"
            render={() => <SignOutPage action="signout" />}
          />
          <Route path="/signout-callback" component={HomePage} /> */}
          <Route path="/post/:slug" element={<PostContent />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<SignUp />} />
          <Route element={<NotFoundPage />} />
        </Routes>
      </BrowserRouter>
    </ApolloProvider>
  );
};

export default App;
