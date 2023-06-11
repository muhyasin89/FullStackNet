<script lang="ts">
import { defineComponent } from 'vue';
import MainLayout from '../../layouts/MainLayout.vue';


export default defineComponent({
  name: "home-view",
  components: {
    MainLayout,
  }
});

</script>

<template>
    <div id="user">
        <main-layout>
            <Suspense>
                <template #default>
                    <h1>Welcome User</h1>
                </template>
                <template #fallback>
                    <LoadingComponent />
                </template>
            </Suspense>

        </main-layout>
    </div>
</template>