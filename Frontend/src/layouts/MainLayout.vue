<script setup lang="ts">
import SideBarNav from '../layouts/SideBarNav.vue';

</script>
<template>
    <div id="auth">
        <side-bar-nav />
        <div class="p-4 sm:ml-64">
            <div class="p-4 border-2 border-gray-200 border-dashed rounded-lg dark:border-gray-700">
                <nav-bar></nav-bar>
                <slot></slot>
            </div>
        </div>
    </div>
</template>