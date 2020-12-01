import { Profile } from '../users/profile/profile.model';

export interface Ad {
    id: number;
    title: string;
    price: string;
    description: string;
    imageUrl: string;
    category: number;
    isActive: boolean;
    //user: Profile;
}