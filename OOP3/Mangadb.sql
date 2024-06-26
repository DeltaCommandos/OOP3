PGDMP  9                    |            Mangadb    16.3    16.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    40963    Mangadb    DATABASE     }   CREATE DATABASE "Mangadb" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Mangadb";
                postgres    false            �            1259    40971    Series    TABLE     �   CREATE TABLE public."Series" (
    id integer NOT NULL,
    name character varying(40) NOT NULL,
    chapters integer NOT NULL,
    author_id integer NOT NULL
);
    DROP TABLE public."Series";
       public         heap    postgres    false            �            1259    40970    Author_id_seq    SEQUENCE     �   ALTER TABLE public."Series" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Author_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    40982    Authors    TABLE     d   CREATE TABLE public."Authors" (
    id integer NOT NULL,
    name character varying(40) NOT NULL
);
    DROP TABLE public."Authors";
       public         heap    postgres    false            �            1259    40981    Authors_id_seq    SEQUENCE     �   ALTER TABLE public."Authors" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Authors_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    219            �            1259    40965 
   Characters    TABLE     �   CREATE TABLE public."Characters" (
    id integer NOT NULL,
    name character varying(20),
    age integer,
    series_id integer
);
     DROP TABLE public."Characters";
       public         heap    postgres    false            �            1259    41003    Characters_id_seq    SEQUENCE     �   ALTER TABLE public."Characters" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Characters_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �          0    40982    Authors 
   TABLE DATA           -   COPY public."Authors" (id, name) FROM stdin;
    public          postgres    false    219   �       �          0    40965 
   Characters 
   TABLE DATA           @   COPY public."Characters" (id, name, age, series_id) FROM stdin;
    public          postgres    false    215   �       �          0    40971    Series 
   TABLE DATA           A   COPY public."Series" (id, name, chapters, author_id) FROM stdin;
    public          postgres    false    217   '       �           0    0    Author_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Author_id_seq"', 3, true);
          public          postgres    false    216            �           0    0    Authors_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Authors_id_seq"', 2, true);
          public          postgres    false    218            �           0    0    Characters_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Characters_id_seq"', 4, true);
          public          postgres    false    220            ]           2606    40975    Series Author_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Series"
    ADD CONSTRAINT "Author_pkey" PRIMARY KEY (id);
 @   ALTER TABLE ONLY public."Series" DROP CONSTRAINT "Author_pkey";
       public            postgres    false    217            _           2606    40988    Authors Authors_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Authors"
    ADD CONSTRAINT "Authors_pkey" PRIMARY KEY (id);
 B   ALTER TABLE ONLY public."Authors" DROP CONSTRAINT "Authors_pkey";
       public            postgres    false    219            [           2606    41008    Characters Characters_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Characters"
    ADD CONSTRAINT "Characters_pkey" PRIMARY KEY (id);
 H   ALTER TABLE ONLY public."Characters" DROP CONSTRAINT "Characters_pkey";
       public            postgres    false    215            `           2606    41012    Characters series_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Characters"
    ADD CONSTRAINT series_id_fk FOREIGN KEY (series_id) REFERENCES public."Series"(id) NOT VALID;
 C   ALTER TABLE ONLY public."Characters" DROP CONSTRAINT series_id_fk;
       public          postgres    false    215    4701    217            �       x�3��,��LIT.��2��L������ T�      �   /   x�3�tI����4��4�2��/�N�4��4�2�̨��c���� ���      �   6   x�3�t�H��+N,W�M��4�4�2��vuuqut	p��q�44	��qqq 3:     