export class GoogleChartModel {
    title: string
    type: string
    data: Array<Array<string | number | {}>>
    roles?: Array<{ type: string, role: string, index?: number }>
    columnNames?: Array<string>
    options?: {}
}