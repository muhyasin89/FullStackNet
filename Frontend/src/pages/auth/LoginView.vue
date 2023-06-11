<script lang="ts">
import AuthLayout from '../../layouts/AuthLayout.vue';
import LoginForm  from '../../components/form/LoginForm.vue';
import { defineComponent } from "vue";
export default defineComponent({
    name: "LoginView",
    data() {
        return {

        }
    },
    components: {
        AuthLayout,
        LoginForm
    }

})
</script>
<template>
      <auth-layout>
        <login-form />
      </auth-layout>
</template>