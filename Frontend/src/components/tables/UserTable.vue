<template>
    Record User is: {{ msg }}
    <EasyDataTable :headers="headers" :items="items" :filter-options="filterOptions" show-index>
        <template #header-username="header">
            <div class="filter-column">
                <font-awesome-icon icon="fa-search" class="filter-icon" @click.stop="showUserName = !showUserName" />
                {{ header.text }}
                <div class="filter-menu" v-if="showUserName">
                    <input v-model="userName" />
                </div>
            </div>
        </template>
        <template #item-dob="{ dob }">
            {{ ChangeIsoToDate(dob) }}
        </template>
    </EasyDataTable>
</template>

<script setup lang="ts">
import { computed, ref, toRefs } from "vue";
import { FilterOptionModified } from "../../interface/FilterOptionModified";
import { Header } from "vue3-easy-data-table";
import { ChangeIsoToDate } from "../../utilities/ChangeDate";


export interface Props {
    msg?: string
    items?: any[]
}
const props = defineProps<{
    items: any[],
    msg: string
}>();

let { items, msg } = toRefs(props);

const showUserName = ref(false);
const userName = ref('');

const headers: Header[] = [
    { text: "Username", value: "username", fixed: true, sortable: true },
    { text: "Email", value: "email", sortable: true },
    { text: "Date Of Birth", value: "dob", sortable: true },
    { text: "Phone", value: "phoneNumber", sortable: true }
];

const filterOptions = computed((): FilterOptionModified[] => {
    const filterOptionsArray: FilterOptionModified[] = [];

    filterOptionsArray.push({
        field: 'username',
        criteria: userName.value,
        comparison: (value, criteria): boolean => (value != null && criteria != null &&
            typeof value === 'string' && value.toLowerCase().includes(`${criteria}`)),
    });
    return filterOptionsArray;

})
</script>