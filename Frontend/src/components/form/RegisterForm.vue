<script setup lang="ts">
import { ErrorSwal, CheckUnidentified } from '../../utilities/ValidateHelp';
import { Form, Field, ErrorMessage } from 'vee-validate';
import { useAuthStore } from '../../stores/auth';
import { useRootStore } from '../../stores/root';
import { ChangeDateValue } from '../../utilities/ChangeDate';
import Swal from 'sweetalert2';
import { useRouter } from 'vue-router';


const authStore = useAuthStore();
const rootStore = useRootStore();
const router = useRouter();

const submitForm = async (values: any) => {
    if (values["password"] != values["confirm_password"]) {
        let msg = "Password dan confirm password harus sama";
        ErrorSwal(msg)
    }

    if (CheckUnidentified(authStore.registerData.dob)) {
        let msg = "Date of Birth harus di input";
        ErrorSwal(msg)
    } else {
        authStore.registerData.dob = ChangeDateValue(authStore.registerData.dob);
        const requestOptions = {
            method: "POST",
            headers: rootStore.GetHeaderLogin(),
            body: JSON.stringify(authStore.registerData)
        };
        fetch(rootStore.host+ "Auth/register", requestOptions)
        .then(response => response.json())
        .catch(error => {
            let err_message = error.json();
            ErrorSwal(err_message.toString())
        })
        .then(data=> {
            var serialize_data = JSON.stringify(data);
            
            Swal.fire("Success", serialize_data.toString(), "success");
            router.push({ name: 'login' });
        });
    }

    // alert(JSON.stringify(authStore.registerData));
}

const validateEmail = (value: any) => {
    // if the field is empty
    if (!value) {
        return 'This field is required';
    }
    // if the field is not a valid email
    const regex = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
    if (!regex.test(value)) {
        return 'This field must be a valid email';
    }
    // All is good
    return true;
}


const validatePhone = (value: any) => {
    // if the field is empty
    if (!value) {
        return 'This field is required';
    }
    // if the field is not a valid phone
    const regex = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
    if (!regex.test(value)) {
        return 'This field must be a valid phone';
    }
    // All is good
    return true;
}
const validateRequired = (value: any) => {
    if (!value) {
        return 'This field is required';
    }

    return true;
}

const TimeFormat = (date: any) => {
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear();

    return `${year}-${month}-${day}`;
}

</script>

<template>
    <Form class="space-y-4 md:space-y-6" @submit="submitForm">

        <div>
            <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Your
                email</label>
            <Field type="email" name="email" v-model="authStore.registerData.email" id="email"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                placeholder="name@company.com" :rules="validateEmail" />
            <ErrorMessage name="email" />
        </div>
        <div>
            <label for="nama" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Nama</label>
            <Field type="text" name="nama" id="nama" v-model="authStore.registerData.name"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                placeholder="alo" :rules="validateRequired" />
            <ErrorMessage name="nama" />
        </div>
        <div>
            <label for="phoneNumber" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Your
                phone</label>
            <Field type="text" name="phoneNumber" v-model="authStore.registerData.phoneNumber" id="email"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                placeholder="081112233" :rules="validatePhone" />
            <ErrorMessage name="phoneNumber" />
        </div>
        <div>
            <label for="dob" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Date Of Birth</label>
            <VueDatePicker v-model="authStore.registerData.dob" :enable-time-picker="false" :format="TimeFormat">
            </VueDatePicker>
        </div>
        <div>
            <label for="username" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Username</label>
            <Field type="text" name="username" id="username" v-model="authStore.registerData.username"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                placeholder="alo" :rules="validateRequired" />
            <ErrorMessage name="username" />
        </div>
        <div>
            <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Password</label>
            <Field type="password" name="password" id="password" placeholder="••••••••"
                v-model="authStore.registerData.password"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                :rules="validateRequired" />
            <ErrorMessage name="password" />
        </div>
        <div>
            <label for="confirm_password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Confirm
                password</label>
            <Field type="password" :rules="validateRequired" name="confirm_password"
                v-model="authStore.registerData.password2" id="confirm-password" placeholder="••••••••"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
            <ErrorMessage name="confirm_password" />
        </div>

        <button type="submit"
            class="text-white w-full bg-red-700 hover:bg-red-800 focus:outline-none focus:ring-4 focus:ring-red-300 font-medium rounded-full text-sm px-5 py-2.5 text-center mr-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">Create
            an account</button>
        <p class="text-sm font-light text-gray-500 dark:text-gray-400">
            Already have an account? <router-link to="/login"
                class="font-medium text-primary-600 hover:underline dark:text-primary-500">Login here</router-link>
        </p>
    </Form>
</template>