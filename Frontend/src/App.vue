<script setup lang="ts">
import { onMounted } from 'vue';
import router from './router';
import { useAuthStore } from "./stores/auth";
import { useRootStore } from "./stores/root";

import { EnvViteType } from "./interface/ViteEnvType";

const authStore = useAuthStore();
const IsAuthentication = authStore.isAuthenticated;

const rootStore = useRootStore();



onMounted(() => {
  let env_vite: EnvViteType = {
    'host': import.meta.env.VITE_BASE_URL,
  }

  // set host in state
  rootStore.ChangeEnv(env_vite);

  if (IsAuthentication == true) {
    router.push({ name: 'user' });
  } else {
    router.push({ name: 'login' });
  }
})


</script>

<template>
  <div id="app" >
    <router-view />
  </div>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}

.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}

.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
