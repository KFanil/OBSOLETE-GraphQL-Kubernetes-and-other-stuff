import { useLazyQuery } from '@apollo/client';
import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

import { GET_CATEGORIES } from '../Services/graphql/queries.graphql';
import { GetCategories } from '../Services/graphql/__generated__/GetCategories';

const Categories = () => {
  const [data, setCategories] = useState<GetCategories>();

  const [getCategories, { data: categories }] = useLazyQuery(GET_CATEGORIES);

  useEffect(() => {
    getCategories().then((newCategories) => {
      setCategories(newCategories.data);
    });
  }, []);

  return (
    <div className="bg-white shadow-lg rounded-lg p-8 pb-12 mb-8">
      <h3 className="text-xl mb-8 font-semibold border-b pb-4">Categories</h3>
      {data?.categories.map((category, index) => (
        <Link key={index} to={`/category/${category.slug}`}>
          <span
            className={`cursor-pointer block ${
              index === data.categories.length - 1 ? 'border-b-0' : 'border-b'
            } pb-3 mb-3`}
          >
            {category.name}
          </span>
        </Link>
      ))}
    </div>
  );
};

export default Categories;
