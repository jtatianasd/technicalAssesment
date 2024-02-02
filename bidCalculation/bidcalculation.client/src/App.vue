<script setup>
    import BidCalculation from './components/BidCalculation.vue'

</script>

<template>
    <header>
        <h1>Bid Calculation</h1>
        <br />

        <p>
            This component allow a buyer to calculate the total price of a vehicle.<br>

            Tatiana Salamanca - 2024
        </p>


        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started.
        </div>
    </header>
    <main>
        <BidCalculation />
    </main>
</template>

<style scoped>
    header {
        line-height: 1.5;
    }
</style>
