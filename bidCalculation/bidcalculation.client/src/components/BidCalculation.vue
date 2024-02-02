<template>
    <div class="bid-component">

        <div id="formBid">
            <form @submit.prevent="submitForm">
                <label for="price">Vehicle Price:</label>
                <input type="text" id="price" v-model="price" required @keyup="calculate">
                <br>
                <label for="Type">Vehicle Type:</label>
                <select id="Type" v-model="vehicleType" required @change="calculate">
                    <option value="Common">Common</option>
                    <option value="Luxury">Luxury</option>
                </select>
                <br>
            </form>
        </div>
        <Errors v-show="errors" :errors="errors" />
        <div>
            <table>
                <thead>
                    <tr>
                        <th>Price</th>
                        <th>Vehicle Type</th>
                        <th>Basic Fee</th>
                        <th>Special Fee</th>
                        <th>Associate Fee</th>
                        <th>Storage Fee</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{{ formatCurrency(bid.price)}}</td>
                        <td>{{ formatCurrency(bid.vehicleType) }}</td>
                        <td>{{ formatCurrency(bid.basic) }}</td>
                        <td>{{ formatCurrency(bid.special) }}</td>
                        <td>{{ formatCurrency(bid.association) }}</td>
                        <td>{{ formatCurrency(bid.storage) }}</td>
                        <td>{{ formatCurrency(bid.total) }}</td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>
</template>

<script>
    import axios from 'axios';
    import Errors from './Error.vue';
    export default
        {
            components: {
                Errors
            },
            data()
            {
                return {
                    vehicleType: 'Common',
                    bid: {
                        price: '',
                        vehicleType: '',
                        basic: 0,
                        special: 0,
                        association: 0,
                        storage: 0,
                        total: 0

                    },
                    errors: ""
                }
            },
            methods:
            {
                calculate()
                {
                    if (this.price > 0) {

                        axios.post(('bid'),
                            {
                                price: this.price,
                                vehicleType: this.vehicleType
                            }).then((response) => {
                                this.bid.price = response.data.price;
                                this.bid.vehicleType = response.data.vehicleType;
                                this.bid.total = response.data.total;
                                this.bid.basic = response.data.basic;
                                this.bid.special = response.data.special;
                                this.bid.association = response.data.association;
                                this.bid.storage = response.data.storage;
                                this.errors = '';
                            }).catch(error => {
                                this.errors = error.message;
                            })
                    }
                    else
                    {
                        this.errors = 'The price must be greater than zero.';
                        this.bid.price = 0;
                        this.bid.vehicleType = '';
                        this.bid.total = 0;
                        this.bid.basic = 0;
                        this.bid.special = 0;
                        this.bid.association = 0;
                        this.bid.storage = 0;
                    }
                },
                formatCurrency(value) {
                    return value.toLocaleString('en-EN', {
                        style: 'currency',
                        currency: 'USD',
                    });
                },


            }
        }
</script>

<style scoped>
    th {
        font-weight: bold;
        background-color: #f2f2f2;
    }

    th, td {
        border: 1px solid #ddd;
        padding: 8px;
        text-align: left;
    }

    table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    form {
        max-width: 300px;
        margin: 20px auto;
    }

        form label {
            display: block;
            margin-bottom: 8px;
        }

        form input,
        form select {
            width: 100%;
            padding: 8px;
            margin-bottom: 16px;
            box-sizing: border-box;
        }
</style>