<script lang="ts">
import { defineComponent } from 'vue';
import MainLayout from '../../layouts/MainLayout.vue';
import { useQuery } from "vue-query";
import { useRootStore } from '../../stores/root';

const rootStore = useRootStore();

function useTodosQuery() {
    return useQuery("users", fetchUsers);
}

function fetchUsers() {
    const requestOptions = {
        method: "GET",
        headers: {
            "Content-type": "application/json",
            Authorization: `Bearer ${rootStore.token}`,
        }
    };
    return fetch(rootStore.host + "User", requestOptions)
        .then(response => response.json())
        .then(data => {
            return data;
        });

}

export default defineComponent({
    name: "home-view",
    components: {
        MainLayout,
    },
    mounted() {
        console.log(rootStore.GetHeaderLogin());
    },
    setup() {
        const { isLoading, isError, data, error, isFetching } = useTodosQuery();

        return { isLoading, isError, data, error, isFetching };
    },
});

</script>

<template>
    <div id="user">
        <main-layout>
            <Suspense>
                <template #default>
                    <span v-if="isLoading">
                        <LoadingComponent />
                    </span>
                    <span v-else-if="isError">Error: {{ error.message }}</span>
                    <!-- We can assume by this point that `isSuccess === true` -->
                    <ul v-else>
                        <li v-for="user in data.data" :key="user.id">{{ user.username }}</li>
                    </ul>
                </template>
                <template #fallback>
                    <LoadingComponent />
                </template>
            </Suspense>

        </main-layout>
    </div>
</template>