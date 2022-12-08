import styled from '@emotion/styled';

export const gray1 = '#383737';
export const gray2 = '#5c5a5a';
export const gray3 = '#857c81';
export const gray4 = '#b9b9b9';
export const gray5 = '#e3e2e2';
export const gray6 = '#f7f8fa';
export const primary1 = '#681c41';
export const primary2 = '#824c67';
export const accent1 = '#dbb365';
export const accent2 = '#efd197';
export const fontFamily = "'Segoe UI', 'Helvetica Neue',sans-serif";
export const fontSize = '16px';

export const PrimaryButton = styled.button`
  display: inline-block;
  padding-top: 0.75rem;
  padding-bottom: 0.75rem;
  padding-left: 2rem;
  padding-right: 2rem;
  background-color: #db2777;
  transition-property: background-color, border-color, color, fill, stroke,
    opacity, box-shadow, transform;
  transition-duration: 500ms;
  color: #ffffff;
  font-size: 1.125rem;
  line-height: 1.75rem;
  font-weight: 500;
  border-radius: 9999px;
  cursor: pointer;
`;

export const StatusText = styled.div`
  text-align: center;
  margin: 5em 0;
`;
