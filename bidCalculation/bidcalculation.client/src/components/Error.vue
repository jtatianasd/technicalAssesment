<template>
    <div class="error-message">
        {{ errors }}
    </div>
</template>

<script>
    export default {
        name: 'Errors',
        props: {
            errors: {}
        }
    }
</script>
<style scoped>
    .error-message {
        background-color: #f8d7da;
        border: 1px solid #f5c6cb;
        color: #721c24;
        padding: 10px;
        margin-bottom: 10px;
        border-radius: 5px;
    }
</style>