import { Profile } from '../users/profile/profile.model';

export interface Ad {
    id?: number;
    title: string;
    price: string;
    description: number;
    imageUrl: [];
    category: string;
    isActive?: boolean;
    user?: Profile;
}