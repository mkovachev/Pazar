export interface Ad {
    id: number;
    title: string;
    price: number;
    description: string;
    imageUrl: string;
    isActive: boolean;
    categoryId: number;
    category: string;
}