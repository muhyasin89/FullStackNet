import Swal from "sweetalert2";

export const ErrorSwal = (msg: string) => {
  Swal.fire("Form Error", msg, "error");
};

export const CheckUnidentified = (data: any) => {
  if (data == "" || data == undefined) {
    return true;
  } else {
    return false;
  }
};

export const validateRequired = (value: any) => {
  if (!value) {
    return "This field is required";
  }

  return true;
};
