import { Profile } from '../users/profile/profile.model';

export interface Ad {
    id: number;
    title: string;
    price: number;
    description: string;
    imageUrl: string;
    isActive: boolean;
    categoryId: number;
    //user: Profile;
}