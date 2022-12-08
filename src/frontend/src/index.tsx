import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement,
);
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

// import React from 'react';
// import ReactDOM from 'react-dom/client';
// import './index.css';
// import App from './App';
// import reportWebVitals from './reportWebVitals';
// import { BrowserRouter, Route, Routes } from 'react-router-dom';
// import HomePage from './Pages/HomePage';
// import Header from './Pages/Header';

// import { FC } from 'react';

// interface Props {
//   children?: React.ReactNode;
// }

// export const Layout: FC<Props> = ({ children }) => (
//   <div>
//     <Header />
//     {children}
//   </div>
// );

// const root = ReactDOM.createRoot(
//   document.getElementById('root') as HTMLElement,
// );
// root.render(
//   <Layout>
//     <BrowserRouter>
//       <Routes>
//         <Route path="/" element={<App />} />
//       </Routes>
//     </BrowserRouter>
//   </Layout>,
// );

// // If you want to start measuring performance in your app, pass a function
// // to log results (for example: reportWebVitals(console.log))
// // or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
// reportWebVitals();
