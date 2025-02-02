import { FieldError, RegisterOptions } from "react-hook-form";
import { BaseFragrance } from "./FragranceDto";

export type PaginationProps = {
  page: number;
  setPage: (page: number) => void;
  numberOfPages: number;
  isPreviousData: boolean;
};

export type FragranceCardProps = {
  id: number;
  image: string;
  name: string;
  gender: string;
};

export type PasswordFieldProps = {
  register: any;
  error?: FieldError;
};

export type InputFieldProps = PasswordFieldProps & {
  id: string;
  label: string;
  placeholder?: string;
  type?: "text";
  validationRules: RegisterOptions;
};

export type SelectFieldProps = {
  register: any;
  id: string;
  label: string;
  options: Array<string>;
};

export type SelectableFragranceCardProps = BaseFragrance & {
  onSelect: (id: number, selected: boolean) => void;
  selected: boolean;
};
