<template>
    <div>
        <h1>Weather forecast</h1>

<!--      <span>Amount of days:</span>-->
<!--      <select v-model="selectedAmountDaysOption">-->
<!--        <option v-for="option in amountDaysOptions" v-bind:value="option">-->
<!--          {{ option }}-->
<!--        </option>-->
<!--      </select>-->

      <span>City:</span>
      <select v-model="selectedCityOption">
        <option v-for="option in citiesOptions" v-bind:value="option">
          {{ option.name }}
        </option>
      </select>

      <span>Source:</span>
      <select v-model="selectedProviderOption">
        <option v-for="option in providersOptions" v-bind:value="option">
          {{ option }}
        </option>
      </select>

      <span>Units:</span>
      <select v-model="selectedUnitOptions">
        <option v-for="option in unitsOptions" v-bind:value="option">
          {{ option }}
        </option>
      </select>
      <span>Language:</span>
      <select v-model="selectedLangOptions">
        <option v-for="option in languagesOptions" v-bind:value="option">
          {{ option }}
        </option>
      </select>
      <button v-on:click="show">Load</button>

        <div v-if="!forecasts" class="text-center">
            <p><em>Loading...</em></p>
            <h1><icon icon="spinner" pulse/></h1>
        </div>
        <template v-if="forecasts">
            <table class="table">
                <thead class="dark-bg text-white">
                    <tr>
                        <th>Date</th>
                        <th>Temperature</th>
                        <th>Pressure</th>
                        <th>Precipitation Period</th>
                    </tr>
                </thead>
                <tbody>
                    <tr :class="index % 2 == 0 ? 'bg-white' : 'bg-light'" v-for="(forecast, index) in forecasts" :key="index">
                        <td>{{ forecast.dateTime }}</td>
                        <td>{{ forecast.temperature }}</td>
                        <td>{{ forecast.pressure }}</td>
                        <td>{{ forecast.precipPeriod}}</td>
                    </tr>
                </tbody>
            </table>
        </template>

      <h6>Last updated date: {{lastUpdated}}</h6>
    </div>
</template>

<script>
export default {
  data () {
    return {
      connection: null,
      forecasts: null,
      lastUpdated: null,

      amountDaysOptions: [],
      selectedAmountDaysOption: 5,
      citiesOptions: [],
      selectedCityOption: { name:"New York", latitude: 43, longitude: -75.5},
      providersOptions: [],
      selectedProviderOption: "All",
      unitsOptions: [],
      selectedUnitOptions: "Imperial",
      languagesOptions: [],
      selectedLangOptions: "English"
    }
  },

  methods: {
    async loadOptionsData(){
        let selectOptionsData = await this.$http.get('/api/weather/GetSelectOptionsData');
        this.amountDaysOptions = selectOptionsData.data.amountDays;
        this.citiesOptions = selectOptionsData.data.cities;
        this.providersOptions = selectOptionsData.data.providers;
        this.unitsOptions = selectOptionsData.data.units;
        this.languagesOptions = selectOptionsData.data.languages;

      console.log(this.citiesOptions)
    },
    async loadTable() {
      try {
        let response = await this.$http.get(`/api/weather/weatherforecast?days=${this.selectedAmountDaysOption}&lat=${this.selectedCityOption.latitude}`
          +`&lon=${this.selectedCityOption.longitude}&provider=${this.selectedProviderOption}&units=${this.selectedUnitOptions}&lang=${this.selectedLangOptions}`);

        this.forecasts = response.data;
        this.lastUpdated = new Date().toLocaleString();

        setTimeout(this.loadTable, 60000);//1 min
      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    }
    ,
    setConnection(){
      this.connection = new this.$signalR.HubConnectionBuilder()
      .withUrl("/weather")
      .configureLogging(this.$signalR.LogLevel.Error)
      .build();
    },
    show: function () {
      this.loadTable();
    },
  },
  mounted: function () {
    /*
    this.connection.start()
      .then(() => {
        //sendEvent
      });

    this.connection.on('weather', data => {
      this.forecasts = data;
      // this.lastUpdated = new Date().toLocaleString();
    });
    */
  },
  created () {
    // this.setConnection();
    this.loadOptionsData();
    this.loadTable();
  }
}
</script>

<style>
</style>
