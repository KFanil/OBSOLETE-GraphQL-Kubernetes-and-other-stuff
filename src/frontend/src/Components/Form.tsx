import { FC, useState, createContext, FormEvent } from 'react';
import { PrimaryButton, gray5, gray6 } from '../Styles/Styles';
/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';

export interface Values {
  [key: string]: any;
}
interface Props {
  submitCaption?: string;
  validationRules?: ValidationProp;
  onSubmit: (values: Values) => Promise<SubmitResult>;
  successMessage?: string;
  failureMessage?: string;
  children?: React.ReactNode;
}
interface FormContextProps {
  values: Values;
  setValue?: (fieldName: string, value: any) => void;
  errors: Errors;
  validate?: (fieldName: string) => void;
  touched: Touched;
  setTouched?: (fieldName: string) => void;
}
export const FormContext = createContext<FormContextProps>({
  values: {},
  errors: {},
  touched: {},
});
type Validator = (value: any, args?: any) => string;
export const required: Validator = (value: any): string =>
  value === undefined || value === null || value === ''
    ? 'This must be populated'
    : '';

export const minLength: Validator = (value: any, length: number): string =>
  value && value.length < length
    ? `This must be at least ${length} characters`
    : '';

interface Validation {
  validator: Validator;
  arg?: any;
}
interface ValidationProp {
  [key: string]: Validation | Validation[];
}
export interface Errors {
  [key: string]: string[];
}
export interface Touched {
  [key: string]: boolean;
}
export interface SubmitResult {
  success: boolean;
  errors?: Errors;
}

export const Form: FC<Props> = ({
  submitCaption,
  children,
  validationRules,
  onSubmit,
  successMessage = 'Success!',
  failureMessage = 'Something went wrong',
}) => {
  const [values, setValues] = useState<Values>({});
  const [errors, setErrors] = useState<Errors>({});
  const [touched, setTouched] = useState<Touched>({});
  const [submitting, setSubmitting] = useState(false);
  const [submitted, setSubmitted] = useState(false);
  const [submitError, setSubmitError] = useState(false);

  const validate = (fieldName: string): string[] => {
    if (!validationRules) {
      return [];
    }
    if (!validationRules[fieldName]) {
      return [];
    }
    const rules = Array.isArray(validationRules[fieldName])
      ? (validationRules[fieldName] as Validation[])
      : ([validationRules[fieldName]] as Validation[]);
    const fieldErrors: string[] = [];
    rules.forEach((rule) => {
      const error = rule.validator(values[fieldName], rule.arg);
      if (error) {
        fieldErrors.push(error);
      }
    });
    const newErrors = { ...errors, [fieldName]: fieldErrors };
    setErrors(newErrors);
    return fieldErrors;
  };
  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (validateForm()) {
      setSubmitting(true);
      setSubmitError(false);
      const result = await onSubmit(values);
      setErrors(result.errors || {});
      setSubmitError(!result.success);
      setSubmitting(false);
      setSubmitted(true);
    }
    window.scrollTo(0, document.body.scrollHeight);
  };
  const validateForm = () => {
    const newErrors: Errors = {};
    let haveError: boolean = false;
    if (validationRules) {
      Object.keys(validationRules).forEach((fieldName) => {
        newErrors[fieldName] = validate(fieldName);
        if (newErrors[fieldName].length > 0) {
          haveError = true;
        }
      });
    }
    setErrors(newErrors);
    return !haveError;
  };
  return (
    <FormContext.Provider
      value={{
        values,
        setValue: (fieldName: string, value: any) => {
          setValues({ ...values, [fieldName]: value });
        },
        errors,
        validate,
        touched,
        setTouched: (fieldName: string) => {
          setTouched({ ...touched, [fieldName]: true });
        },
      }}
    >
      <form noValidate={true} onSubmit={handleSubmit}>
        <fieldset disabled={submitting || (submitted && !submitError)}>
          {children}
          <div
            css={css`
              margin: 30px 0px 0px 0px;
              padding: 20px 0px 0px 0px;
              border-top: 1px solid ${gray5};
            `}
          >
            <PrimaryButton type="submit">{submitCaption}</PrimaryButton>
          </div>
          {submitted && submitError && (
            <p
              css={css`
                color: red;
              `}
            >
              {failureMessage}
            </p>
          )}
          {submitted && !submitError && (
            <p
              css={css`
                color: green;
              `}
            >
              {successMessage}
            </p>
          )}
        </fieldset>
      </form>
    </FormContext.Provider>
  );
};
