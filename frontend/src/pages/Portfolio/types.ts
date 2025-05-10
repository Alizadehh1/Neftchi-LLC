export interface FileItem {
    id: number;
    name: string;
    path: string;
    isMain: boolean;
}

export interface IPortfolio {
    id: number;
    description: string;
    name: string;
    files: FileItem[]
}