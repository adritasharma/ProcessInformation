export interface IApplication {
    applicationId: number;
    applicationName: string;
    projectName: string;
}

export class Application implements IApplication {
    constructor(
        public applicationId: number = null,
        public applicationName: string = '',
        public projectName = '') { }
}