import { ApolloClient, InMemoryCache } from '@apollo/client';
import { useMemo } from 'react';

export const useClient = () => {
  const client = useMemo(
    () =>
      new ApolloClient({
        uri: 'http://acme.com/graphql/',
        cache: new InMemoryCache(),
      }),
    [],
  );

  return client;
};
