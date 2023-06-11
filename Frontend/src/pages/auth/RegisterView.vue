<script lang="ts">
import { defineComponent } from 'vue';
import AuthLayout from '../../layouts/AuthLayout.vue';
import RegisterForm from '../../components/form/RegisterForm.vue';

export default defineComponent({
    name: "RegisterView",
    data() {
        return {
        }
    },
    components: {
        AuthLayout,
        RegisterForm
    }
});
</script>

<template>
    <auth-layout>
        <br />
        <br />
        <br />
        <h1 class="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
            Create and account
        </h1>
        <register-form />
    </auth-layout>
</template>