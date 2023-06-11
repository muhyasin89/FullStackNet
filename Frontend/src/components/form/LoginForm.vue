<script setup lang="ts">
import { Form, Field, ErrorMessage } from 'vee-validate';
import { ErrorSwal, validateRequired } from '../../utilities/ValidateHelp';
import { useAuthStore } from '../../stores/auth';
import { useRootStore } from '../../stores/root';
import { useRouter } from 'vue-router';
import Swal from 'sweetalert2';

const authStore = useAuthStore();
const rootStore = useRootStore();
const router = useRouter();

const onSubmit = (values: any) => {
    let data = {
        "username": values['username'],
        "password": values['password']
    }

    const requestOptions = {
        method: "POST",
        headers: rootStore.GetHeaderLogin(),
        body: JSON.stringify(data)
    };
    fetch(rootStore.host + "Auth/login", requestOptions)
    .then(response => response.json())
        .catch(error => {
            let err_message = error.json();
            ErrorSwal(err_message.toString())
        })
        .then(data=> {
            var serialize_data = data;
            
            if(serialize_data["codeStatus"] == 200){
                rootStore.ChangeToken(serialize_data["token"]);
                authStore.changeAuthenticated(true);
                router.push({ name: 'home' });
            }else{
                Swal.fire("Fail", JSON.stringify(serialize_data) , "error");
            }
            
            
        });
    //alert(JSON.stringify(data));

    return data;
}
</script>

<template>
    <Form class="space-y-4 md:space-y-6" @submit="onSubmit">
        <div>
            <label for="username" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email</label>
            <label class="relative text-gray-400 focus-within:text-gray-600 block">

                <svg xmlns="http://www.w3.org/2000/svg"
                    class="pointer-events-none w-8 h-8 absolute top-1/2 transform -translate-y-1/2 left-3"
                    viewBox="0 0 20 20" fill="currentColor">
                    <path d="M2.003 5.884L10 9.882l7.997-3.998A2 2 0 0016 4H4a2 2 0 00-1.997 1.884z" />
                    <path d="M18 8.118l-8 4-8-4V14a2 2 0 002 2h12a2 2 0 002-2V8.118z" />
                </svg>

                <Field type="type" name="username" id="username" placeholder="Username" :rules="validateRequired"
                    class="form-input border sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 appearance-none w-full block pl-14 focus:outline-none" />


            </label>
            <ErrorMessage name="username" />
        </div>
        <div>
            <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Password</label>
            <Field type="password" name="password" id="password" placeholder="••••••••"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                :rules="validateRequired" />
            <ErrorMessage name="password" />
        </div>
        <div class="flex items-center justify-between">
            <div class="flex items-start">
                <div class="flex items-center h-5">
                    <input id="remember" aria-describedby="remember" type="checkbox"
                        class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-primary-600 dark:ring-offset-gray-800">
                </div>
                <div class="ml-3 text-sm">
                    <label for="remember" class="text-gray-500 dark:text-gray-300">Remember me</label>
                </div>
            </div>
            <a class="text-sm font-medium text-primary-600 hover:underline dark:text-primary-500">Forgot
                password?</a>

        </div>
        <button type="submit"
            class="text-white w-full bg-red-700 hover:bg-red-800 focus:outline-none focus:ring-4 focus:ring-red-300 font-medium rounded-full text-sm px-5 py-2.5 text-center mr-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">Sign
            In</button>
        <p class="text-sm font-light text-gray-500 dark:text-gray-400">
            Don’t have an account yet? <router-link to="/register"
                class="font-medium text-primary-600 hover:underline dark:text-primary-500">Sign up</router-link>
        </p>
    </Form>
</template>