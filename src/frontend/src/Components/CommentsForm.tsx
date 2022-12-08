import { useState, FC } from 'react';
// import { submitComment } from '../services';
/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Form, minLength, required } from './Form';
import { Field } from './Field';
import { useMutation as UseMutation } from '@apollo/client';
import { ADD_COMMENT } from '../Services/graphql/queries.graphql';

interface Props {
  postId: number;
  authorId: number;
}
export interface Values {
  [key: string]: any;
}
let postID = 0;
let authorID = 0;

export const CommentsForm: FC<Props> = ({ postId, authorId }) => {
  postID = postId;
  authorID = authorId;
  const now = new Date();
  const [addTodo, { data, loading, error }] = UseMutation(ADD_COMMENT, {
    variables: {
      postId: 1,
      authorId: 1,
      content: '',
      created_At: now,
      updated_At: now,
    },
  });
  const handleSubmit = async (values: Values) => {
    console.log(values['content']);
    let val = values['content'];
    addTodo({
      variables: {
        postId: postID,
        authorId: authorID,
        content: val,
        created_At: now,
        updated_At: now,
      },
    });
    console.log(data);
    console.log(loading);
    console.log(error);
    return { success: true ? true : false };
  };

  return (
    <div className="bg-white shadow-lg rounded-lg p-8 pb-12 mb-8">
      <h3 className="text-xl mb-8 font-semibold border-b pb-4">
        Leave a Reply
      </h3>
      <div
        css={css`
          margin-top: 20px;
        `}
      >
        <Form
          submitCaption="Submit Your Comment"
          validationRules={{
            content: [
              { validator: required },
              { validator: minLength, arg: 1 },
            ],
          }}
          onSubmit={handleSubmit}
          failureMessage="There was a problem with your comment"
          successMessage="Your comment was successfully submitted"
        >
          <Field name="content" label="Your Comment" type="TextArea" />
        </Form>
      </div>
    </div>
  );
};

export default CommentsForm;
function variables(
  variables: any,
  arg1: {
    postId: number;
    authorId: number;
    content: string;
    created_At: Date;
    updated_At: Date;
  },
) {
  throw new Error('Function not implemented.');
}
