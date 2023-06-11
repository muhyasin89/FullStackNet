import Swal from 'sweetalert2';

export const errorSwal = (msg: string) => {
    Swal.fire("Form Error", msg, "error");
}