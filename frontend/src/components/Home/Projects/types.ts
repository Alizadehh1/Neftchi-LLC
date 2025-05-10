export interface IFile {
    id: number;
    name: string;
    path: any;
    isMain:any;
}

export interface IProject {
    id: number;
    organisationShortName: string;
    file: IFile;
}

export interface OneIProject {
    id: number;
    name: string;
    organisationName: string;
    description: string;
    employeeNumber: number;
    date: string;
    deliveryDate: string;
    materials: string;
    files: IFile[];
}