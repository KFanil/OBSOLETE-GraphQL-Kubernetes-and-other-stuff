import { FC } from 'react';
import { PageTitle } from './PageTitle';
import React from 'react';

interface Props {
  title?: string;
  children?: React.ReactNode;
}

export const Page: FC<Props> = ({ title, children }) => (
  <div>
    {title && <PageTitle>{title}</PageTitle>}
    {children}
  </div>
);
