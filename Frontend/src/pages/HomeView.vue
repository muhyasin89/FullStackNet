<script lang="ts">
import { defineComponent } from 'vue';
import MainLayout from '../layouts/MainLayout.vue';

import { useRootStore } from '../stores/root';

export default defineComponent({
  name: "home-view",
  components: {
    MainLayout,
  },
  mounted(){
    const rootStore = useRootStore();
    console.log(rootStore.token); 
  }
});

</script>

<template>
    <div id="home">
        <main-layout>
            <Suspense>
                <template #default>
                    <h1>Welcome Home</h1>
                </template>
                <template #fallback>
                    <LoadingComponent />
                </template>
            </Suspense>

        </main-layout>
    </div>
</template>