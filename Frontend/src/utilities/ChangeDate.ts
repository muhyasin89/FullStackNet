import moment from "moment";

export const ChangeIsoToDate = (date_iso: any) => {
  return moment(date_iso).format("YYYY-MM-DD");
};

export const ChangeStringToDate = (value: string) => {
  return new Date(value);
};

export const IsIsoDate = (date_value: any) => {
  return moment(date_value, moment.ISO_8601).isValid();
};

export const ChangeToIso = (value: string) => {
  return new Date(new Date(value).toISOString());
};

export const ChangeDateValue = (date_value: any) => {
  if (IsIsoDate(date_value) == true) {
    return ChangeIsoToDate(date_value);
  } else {
    return date_value;
  }
};
