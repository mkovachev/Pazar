import { Ad } from '../ads/ad.model';

export interface Category {
    id: number;
    name: string;
    imageUrl: string;
    totalAds: number;
}