Vue.component('pie-chart', {
    extends: VueChartJs.Pie,
    props: {
        chartdata: {
            type: Object,
            default: null
        },
        options: {
            type: Object,
            default: null
        }
    },

    watch: {
        chartdata() {
            this.renderChart(this.chartdata, this.options)
        }
    },

    mounted() {
        this.renderChart(this.chartdata, this.options)
    }

})
