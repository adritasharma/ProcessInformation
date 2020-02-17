export interface IApplication {
    applicationId: string;
    applicationName: string;
    projectName: string;
}

export class Application implements IApplication {
    constructor(
        public applicationId: string = null,
        public applicationName: string = '',
        public projectName = '') { }
}