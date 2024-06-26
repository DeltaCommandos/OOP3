PGDMP                      |            MangO    16.3    16.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16401    MangO    DATABASE     {   CREATE DATABASE "MangO" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "MangO";
                postgres    false                        2615    16430    public    SCHEMA     2   -- *not* creating schema, since initdb creates it
 2   -- *not* dropping schema, since initdb creates it
                postgres    false            �           0    0    SCHEMA public    COMMENT         COMMENT ON SCHEMA public IS '';
                   postgres    false    5            �           0    0    SCHEMA public    ACL     +   REVOKE USAGE ON SCHEMA public FROM PUBLIC;
                   postgres    false    5            �            1259    24593    Organisation    TABLE     �   CREATE TABLE public."Organisation" (
    id integer NOT NULL,
    name character varying(40) NOT NULL,
    kol_members integer NOT NULL
);
 "   DROP TABLE public."Organisation";
       public         heap    postgres    false    5            �            1259    24596    Author_id_seq    SEQUENCE     �   ALTER TABLE public."Organisation" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Author_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    5    215            �            1259    24597    Devil_Fruits    TABLE     i   CREATE TABLE public."Devil_Fruits" (
    id integer NOT NULL,
    name character varying(40) NOT NULL
);
 "   DROP TABLE public."Devil_Fruits";
       public         heap    postgres    false    5            �            1259    24600    Authors_id_seq    SEQUENCE     �   ALTER TABLE public."Devil_Fruits" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Authors_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    5    217            �            1259    24601 
   Characters    TABLE     �   CREATE TABLE public."Characters" (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    age integer NOT NULL,
    org_id integer NOT NULL,
    devil_id integer NOT NULL
);
     DROP TABLE public."Characters";
       public         heap    postgres    false    5            �            1259    24604    Characters_id_seq    SEQUENCE     �   ALTER TABLE public."Characters" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Characters_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    219    5            �          0    24601 
   Characters 
   TABLE DATA           G   COPY public."Characters" (id, name, age, org_id, devil_id) FROM stdin;
    public          postgres    false    219   �       �          0    24597    Devil_Fruits 
   TABLE DATA           2   COPY public."Devil_Fruits" (id, name) FROM stdin;
    public          postgres    false    217          �          0    24593    Organisation 
   TABLE DATA           ?   COPY public."Organisation" (id, name, kol_members) FROM stdin;
    public          postgres    false    215   D       �           0    0    Author_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Author_id_seq"', 4, true);
          public          postgres    false    216            �           0    0    Authors_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Authors_id_seq"', 4, true);
          public          postgres    false    218            �           0    0    Characters_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Characters_id_seq"', 5, true);
          public          postgres    false    220            )           2606    24610    Characters Characters_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Characters"
    ADD CONSTRAINT "Characters_pkey" PRIMARY KEY (id);
 H   ALTER TABLE ONLY public."Characters" DROP CONSTRAINT "Characters_pkey";
       public            postgres    false    219            %           2606    24606    Organisation Organisation_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."Organisation"
    ADD CONSTRAINT "Organisation_pkey" PRIMARY KEY (id);
 L   ALTER TABLE ONLY public."Organisation" DROP CONSTRAINT "Organisation_pkey";
       public            postgres    false    215            '           2606    24608    Devil_Fruits devil_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public."Devil_Fruits"
    ADD CONSTRAINT devil_pkey PRIMARY KEY (id);
 C   ALTER TABLE ONLY public."Devil_Fruits" DROP CONSTRAINT devil_pkey;
       public            postgres    false    217            *           2606    24642    Characters devil_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Characters"
    ADD CONSTRAINT devil_id_fk FOREIGN KEY (devil_id) REFERENCES public."Devil_Fruits"(id) NOT VALID;
 B   ALTER TABLE ONLY public."Characters" DROP CONSTRAINT devil_id_fk;
       public          postgres    false    219    4647    217            +           2606    24611    Characters org_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Characters"
    ADD CONSTRAINT org_id_fk FOREIGN KEY (org_id) REFERENCES public."Organisation"(id) NOT VALID;
 @   ALTER TABLE ONLY public."Characters" DROP CONSTRAINT org_id_fk;
       public          postgres    false    219    4645    215            �      x������ � �      �      x�3�t.��M.�U��W������� B�z      �      x�3�,//�462����� ]�     