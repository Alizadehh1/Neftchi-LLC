export interface FileItem {
    id: number;
    name: string;
    path: string;
    isMain: boolean;
}

export interface ILicense {
    id: number;
    name: string;
    files: FileItem[];
}

export interface ISertificate {
    id: number;
    name: string;
    files: FileItem[];
}


export interface IRecommendation {
    id: number;
    name: string;
    files: FileItem[];
}