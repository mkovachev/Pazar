import { Ad } from '../ads/ad.model';

export interface Category {
    id: number;
    name: string;
    ads: Array<Ad>;
}